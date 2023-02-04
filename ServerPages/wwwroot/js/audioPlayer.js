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