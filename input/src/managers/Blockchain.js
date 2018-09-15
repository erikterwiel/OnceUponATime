const CommandService = require("../services/Command");

class BlockchainManager {
  constructor() {
    this._commandService = new CommandService();
  }

  antiMoss(words) {
    
    this._commandService.sendCommand(words);
  }
}

module.exports = BlockchainManager;
