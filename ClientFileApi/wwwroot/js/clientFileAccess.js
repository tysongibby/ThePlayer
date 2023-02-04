export async function showDirectoryPicker() {
    const dir = await window.showDirectoryPicker();

    // Track the dir in history.state
    const state = history.state || {};
    state.currentDir = dir;
    history.replaceState(state, '');

    return {
        name: dir.name,
        instance: DotNet.createJSObjectReference(dir)
    };
}

export async function reopenLastDirectory() {
    const value = history.state && history.state.currentDir;
    return value ? { name: value.name, instance: DotNet.createJSObjectReference(value) } : null;
}

//export async function getFiles(directory) {
//    // Build an array containing all the file entries
//    const result = [];
//    for await (const entry of directory.values())
//        result.push(await entry.getFile());

//    // For each entry, get name/size/modified
//    return result.map(r => ({ name: r.name, size: r.size, lastModified: r.lastModifiedDate.toISOString(), artist: r.artist }));
//}

// original version without path falue
//export async function getFiles(directoryHandle) {
//    let files = [];
//    for await (const handle of directoryHandle.values()) {
//        if (handle.kind === 'directory') {
//            files.push(...await getFiles(handle));
//        }
//        else if (handle.kind === 'file') {
//            const isMusicFile = hasMusicFileExtension(handle);
//            if (isMusicFile) {
//                files.push(await handle.getFile())
//            }
//        }
//    }
//    return files.map(r => ({ name: r.name, size: r.size }));
//}

export async function getFiles(directoryHandle, relativePath) {
    let files = [];
    
    relativePath += '/' + directoryHandle.name;
    if (relativePath.startsWith('undefined')) {
        relativePath = relativePath.slice(9);
    }

    for await (const handle of directoryHandle.values()) {
        if (handle.kind === 'directory') {
            files.push(...await getFiles(handle, relativePath));
        }
        else if (handle.kind === 'file') {
            const isMusicFile = hasMusicFileExtension(handle);
            if (isMusicFile) {
                const file = await handle.getFile();                
                files.push({ name: file.name, size: file.size, relativePath: relativePath });
            }
        }
        
    }
    relativePath = null;
    return files;
}

function hasMusicFileExtension(handle) {
    let result = false;
    const musicFileExtensionList = ['mp3', 'm4a', 'mp4', 'mpeg', 'flac', 'oog', 'wav'];
    for (const musicFileExtension of musicFileExtensionList) {
        if (handle.name.endsWith(musicFileExtension)) {
            result = true;
            return result;
        }
    }
    return result
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


