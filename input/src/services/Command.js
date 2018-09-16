const fetch = require("node-fetch");

class CommandService {
  sendCommand(command) {
    console.log("Sending command: ", command);
    fetch("https://shrouded-forest-21666.herokuapp.com/", {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ command }),
    });
  }
}

module.exports = CommandService;
