import Dexie from "/js/dexie.js";

export async function showDirectoryPicker() {
    const dir = await window.showDirectoryPicker();

    // Track the dir in history.state
    const state = history.state || {};
    state.currentDir = dir;
    history.replaceState(state, '');

    // Save directory handle to client browser IndexedDb for future use
    const db = new Dexie("HandlesDatabase");
    db.version(1).stores({
        handles: "++id, name, path"
    });

    return {
        name: dir.name,
        instance: DotNet.createJSObjectReference(dir)
    };
}

export async function reopenLastDirectory() {
    const value = history.state && history.state.currentDir;
    return value ? { name: value.name, instance: DotNet.createJSObjectReference(value) } : null;
}

export async function getFiles(directoryHandle, relativePath) {
    let files = [];

    // get relative path
    relativePath += '/' + directoryHandle.name;
    if (relativePath.startsWith('undefined')) {
        relativePath = relativePath.slice(9);
    }

    // if direcotry, recurse to get files from directory; 
    // else, if file add to files array
    for await (const handle of directoryHandle.values()) {
        if (handle.kind === 'directory') {
            files.push(...await getFiles(handle, relativePath));
        }
        else if (handle.kind === 'file') {
            const isAudioFile = hasAudioFileExtension(handle);
            if (isAudioFile) {
                const file = await handle.getFile();                
                //relativePath += '/' + file.name;
                files.push({ name: file.name, size: file.size, relativePath: relativePath });
            }
        }
        
    }
    relativePath = null;
    return files;
}

export function hasAudioFileExtension(handle) {
    let result = false;
    const audioFileExtensionList = ['mp3', 'm4a', 'mp4', 'mpeg', 'flac', 'oog', 'wav'];
    for (const audioFileExtension of audioFileExtensionList) {
        if (handle.name.endsWith(audioFileExtension)) {
            result = true;
            return result;
        }
    }
    return result
}

export async function getDirectoryHandle(relativePath) {
    const handle = await window.resolveLocalFileSystemURL(relativePath);
    return handle;
}

function fileListExtensionFilter(fileNameList, extensionFilterList) {
    let files = [];
    for (const fileName of fileNameList) {
        for (const extensionFilter of extensionFilterList) {
            if (fileName.endsWith(extensionFilter)) {
                files.push(fileName);
            }
        }
    }
    return files;
}

// Audio player functions
export async function decodeAudioFile(name, relativePath) {
    // Read the file
    //const dir = history.state.currentDir;
    const dir = await getDirectoryHandle(relativePath);
    const fileHandle = await dir.getFileHandle(name); // TODO: for some reason blazor webassebmly js is intercepting this js script call and causing an error
    const file = await fileHandle.getFile();
    const fileBytes = await file.arrayBuffer();

    // Decode and extract the audio samples
    const audioBuffer = await new AudioContext().decodeAudioData(fileBytes);
    return new Uint8Array(audioBuffer.getChannelData(0).buffer);
}

export async function playAudioFile(file) {
    const name = file.name;
    const relativePath = file.relativePath;
    const samples = await decodeAudioFile(name, relativePath);
    return playAudioData(samples);
}

export async function playAudioData(samples) {
    // Populate an AudioBuffer object
    const floatData = new Float32Array(samples.buffer);
    const audioContext = new AudioContext();
    const buffer = audioContext.createBuffer(/*numOfChannels*/ 1, floatData.length, /*sampleRate*/ 48000);
    buffer.copyToChannel(floatData, 0);

    // Start playing it
    const source = audioContext.createBufferSource();
    source.buffer = buffer;
    source.connect(audioContext.destination);
    source.start();
    return source;
}


