const bottle = require("./bottle");

// bottle.blockchainManager.show(["there", "was", "a", "pig"], 1);
// bottle.blockchainManager.show(["there", "were", "three", "fireplaces"], 1);
// bottle.blockchainManager.show(["there", "were", "three", "wolves"], 1);
// bottle.blockchainManager.show(["there", "were", "three", "pigs", "and", "there", "were", "four", "fireplaces", "and", "there", "were", "five", "houses"], 1);
const recordingManager = bottle.recordingManager;
recordingManager.start();

console.log("Listening, press Ctrl+C to stop.");
