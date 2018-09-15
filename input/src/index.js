const RecordingManager = require("./managers/Recording");

const recordingManager = new RecordingManager();
recordingManager.start();

console.log("Listening, press Ctrl+C to stop.");
