const record = require("node-record-lpcm16");
const Watson = require("watson-developer-cloud/speech-to-text/v1");
const key = require("./keys/watson");
const fs = require("fs");
const io = require("socket.io-client");

const socket = io("http://localhost:5000/");

const watson = new Watson({
  iam_apikey: key,
  url: "https://gateway-wdc.watsonplatform.net/speech-to-text/api",
});

socket.on("newCommand", () => console.log("got new command"));

const recordInterval = () => {

  const watsonWriteStream = fs.createWriteStream("./tempOutput.txt");
  watsonWriteStream.on("close", () => {
    fs.readFile("./tempOutput.txt", "utf8", (err, contents) => {
      socket.emit("sendCommand", contents );
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
};

setInterval(recordInterval, 10000);
recordInterval();

console.log("Listening, press Ctrl+C to stop.");
