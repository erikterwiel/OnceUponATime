const Bottle = require("bottlejs");
const CommandService = require("./services/Command");
const BlockchainManager = require("./managers/Blockchain");
const RecordingManager = require("./managers/Recording");

const bottle = new Bottle();

bottle.service("commandService", CommandService);
bottle.service("blockchainManager", BlockchainManager, "commandService");
bottle.service("recordingManager", RecordingManager, "blockchainManager");

module.exports = bottle.container;
