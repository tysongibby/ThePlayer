const audioPlayer = new Audio(audioFile);

function play() {

    audioPlayer.play();
}

function pause() {
    audioPlayer.pause();
}

function stop() {
    audioPlayer.pause();
    audioPlayer.currentTime = 0;
}

function repeat() {
    audioPlayer.currentTime = 0;
    audioPlayer.play();
}

export async function decodeAudioFile(name) {
    // Read the file
    const dir = history.state.currentDir;
    const fileHandle = await dir.getFileHandle(name);
    const file = await fileHandle.getFile();
    const fileBytes = await file.arrayBuffer();

    // Decode and extract the audio samples
    const audioBuffer = await new AudioContext().decodeAudioData(fileBytes);
    return new Uint8Array(audioBuffer.getChannelData(0).buffer);
}

export async function playAudioFile(name) {
    const samples = await decodeAudioFile(name);
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