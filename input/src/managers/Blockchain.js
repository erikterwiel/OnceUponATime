const wordpos = require("wordpos");

// OPERATION, OBJECT, DETAIL, AMOUNT
const show = ["built", "was", "were"];
const hide = ["ate", "eight", "down"];
const move = ["came"];
const negation = ["not"];

const nounMap = {
  pig: "Pig/pig",
  house: "HOUSE",
  fireplace: "FirePlace/Prefabs/FP2015"
};

// CommandMap.Add ("brick", "BrickHouse/Prefabs/Baker_house");
// CommandMap.Add ("straw", "StrawHouse/medievalhouse");
// CommandMap.Add ("tree", "Tree/MinecraftTree");
// CommandMap.Add ("wolf", "Wolf/kodi");
// CommandMap.Add ("cauldron", "Cauldron");
// CommandMap.Add ("grass", "green");
// CommandMap.Add ("sky", "blue");

const adjectiveMap = {

};

class BlockchainManager {
  constructor(commandService) {
    this._commandService = commandService;
    this._queue = [];
  }

  antiMoss(words) {

    for (let i = 0; i < words.length; i++) {

      const verb = words[i];
      let command = "";

      if (show === "generate") {

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

      for (let j = i + 1; j < words.length; j++) {
        const noun = words[j];
        if (wordpos.isNoun(noun)) {
          command += noun;
        }
      }

      this._queue.enqueue();

    }


    this._commandService.sendCommand(words);
  }
}

module.exports = BlockchainManager;
