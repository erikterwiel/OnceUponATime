const record = require("node-record-lpcm16");
const Watson = require("watson-developer-cloud/speech-to-text/v1");
const fs = require("fs");
const key = require("../keys/watson");

const watson = new Watson({
  iam_apikey: key,
  url: "https://gateway-wdc.watsonplatform.net/speech-to-text/api",
});

class RecordingManager {
  constructor(blockchainManager) {
    this._blockchainManager = blockchainManager;
    this.start = this.start.bind(this);
    this._recordInterval = this._recordInterval.bind(this);
  }

  start() {
    setInterval(this._recordInterval, 10000);
    this._recordInterval();
  }

  _recordInterval() {
    const watsonWriteStream = fs.createWriteStream("./tempOutput.txt");
    watsonWriteStream.on("close", () => {
      fs.readFile("./tempOutput.txt", "utf8", (err, contents) => {
        this._blockchainManager.antiMoss(contents);
      })
    });

    record
      .start({
        sampleRateHertz: 16000,
        threshold: 0.5,
        verbose: false,
        recordProgram: "rec",
        silence: "2.0",
      })
      .on("error", console.error)
      .pipe(watson.recognizeUsingWebSocket({ content_type: "audio/wav; continuous=true" }))
      .pipe(watsonWriteStream);

    setTimeout(() => record.stop(), 9500)
  }
}

module.exports = RecordingManager;
