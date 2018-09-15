const express = require("express");
const http = require("http");
const socket = require("socket.io");
const record = require("node-record-lpcm16");
const Watson = require("watson-developer-cloud/speech-to-text/v1");
const fs = require("fs");
const key = require("./keys/watson");

const app = express();
const server = http.createServer(app);
const io = socket.listen(server);

const connections = [];

server.listen(process.env.PORT || 3000);

io.sockets.on("connection", (socket) => {
  connections.push(socket);
  console.log(`Connected: ${connections.length} sockets connected`);

  socket.on("disconnect", () => {
    connections.splice(connections.indexOf(socket), 1);
    console.log(`Disconnected: ${connections.length} sockets connected`);
  });
});

const watson = new Watson({
  iam_apikey: key,
  url: "https://gateway-wdc.watsonplatform.net/speech-to-text/api",
});

const recordInterval = () => {

  const watsonWriteStream = fs.createWriteStream("./tempOutput.txt");
  watsonWriteStream.on("close", () => {
    fs.readFile("./tempOutput.txt", "utf8", (err, contents) => {
      console.log("fucking sending to sockets");
      io.sockets.emit("command", { command: contents });
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
