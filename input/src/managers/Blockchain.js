const wordpos = require("wordpos");

// OPERATION, OBJECT, AMOUNT
const show = ["built", "was", "were"];
const hide = ["eight", "down"];
const move = ["came"];
const showMove = [];
const moveHide = ["ate"];

const negation = ["not"];

const nounMap = {
  background: "blue",
  ground: "green",
  pig: "Pig/pig",
  house: "HOUSE",
  fireplace: "FirePlace/Prefabs/FP2015",
  tree: "Tree/MinecraftTree",
};

// CommandMap.Add ("brick", "BrickHouse/Prefabs/Baker_house");
// CommandMap.Add ("straw", "StrawHouse/medievalhouse");
// CommandMap.Add ("wolf", "Wolf/kodi");

const adjectiveMap = {

};

class BlockchainManager {
  constructor(commandService) {
    this._commandService = commandService;
    this._queue = [];
    this.sendCommand = this.sendCommand.bind(this);
    this.antiMoss = this.antiMoss.bind(this);

    this.generate = this.generate.bind(this);
    this.show = this.show.bind(this);
    this.hide = this.hide.bind(this);
    this.move = this.move.bind(this);
    this.showMove = this.showMove.bind(this);
    this.moveHide = this.moveHide.bind(this);

    setInterval(this.sendCommand, 2000);
  }

  sendCommand() {
    if (this._queue.length !== 0) {
      this._commandService.sendCommand(this._queue.shift());
    }
  }

  generate() {
    this._queue.push(`SHOW>${nounMap.background}>1`);
    this._queue.push(`SHOW>${nounMap.ground}>1`);
    this._queue.push(`SHOW>${nounMap.tree}>12`);
  }

  show() {
  }

  hide() {

  }

  move() {

  }

  showMove() {

  }

  moveHide() {

  }

  antiMoss(string) {
    const words = string.split(" ");

    for (let i = 0; i < words.length; i++) {

      const verb = words[i];
      let command = "";

      if (verb === "generate") {
        continue;
      } else if (show.includes(verb)) {
        command += "SHOW";
      } else if (hide.includes(verb)) {
        command += "HIDE";
      } else if (move.includes(verb)) {
        command += "MOVE";
      } else {
        continue;
      }

      command += ">";
      // let nopun

      for (let j = i + 1; j < words.length; j++) {
        const noun = words[j];
        wordpos.isNoun(noun, (isNoun) => {
          if (isNoun) {
            command += noun;
          }
        });
      }

      this._queue.push();

    }

  }
}

module.exports = BlockchainManager;
