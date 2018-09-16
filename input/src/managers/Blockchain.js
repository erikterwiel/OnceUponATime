const Wordpos = require("wordpos");

const wordpos = new Wordpos();

const show = ["built", "was", "were"];
const hide = ["eight", "down"];
const move = ["came"];
const showMove = [];
const moveHide = ["ate"];

const numbers = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "eleven", "twelve"];
const badNouns = ["a"];

const nounMap = {
  background: "blue",
  ground: "green",
  pig: "Pig/pig",
  pigs: "Pig/pig",
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

  async show(words, verbIndex) {
    let number = 1;
    let noun = "";
    let nounIndex;
    let adjective = "";

    for (let i = verbIndex; i < words.length; i++) {
      const word = words[i];

      if (numbers.includes(word)) {
        number = numbers.find(word);
        continue;
      }

      let willBreak = false;

      const isNoun = await new Promise(resolve => {
        wordpos.isNoun(word, isNoun => resolve(isNoun));
      });

      const isReallyNoun = !badNouns.includes(word) && isNoun;
      if (isReallyNoun) {
        noun = word;
        nounIndex = i;
        willBreak = true;
      }

      if (willBreak) {
        break;
      }
    }

    if (nounIndex) {
      wordpos.isAdjective(words[nounIndex - 1], isAdjective => {
        if (isAdjective) {
          adjective = words[nounIndex - 1];
        }
      });

      if (words[nounIndex + 1] === "out" && words[nounIndex + 2] === "of") {
        adjective = words[nounIndex + 2];
      }
    }

    const word = adjective ? `${adjective} ${noun}` : noun;
    const command = `SHOW>${nounMap[word]}>${number}`;

    console.log(command);

    this._queue.push(command);

  }


  hide(words, verbIndex) {

  }

  async move(words, verbIndex) {
    let number = 1;
    let noun = "";
    let nounIndex;
    let adjective = "";

    for (let i = verbIndex; i < words.length; i++) {
      const word = words[i];

      if (numbers.includes(word)) {
        number = numbers.find(word);
        continue;
      }

      let willBreak = false;

      const isNoun = await new Promise(resolve => {
        wordpos.isNoun(word, isNoun => resolve(isNoun));
      });

      const isReallyNoun = !badNouns.includes(word) && isNoun;
      if (isReallyNoun) {
        noun = word;
        nounIndex = i;
        willBreak = true;
      }

      if (willBreak) {
        break;
      }
    }

    if (nounIndex) {
      wordpos.isAdjective(words[nounIndex - 1], isAdjective => {
        if (isAdjective) {
          adjective = words[nounIndex - 1];
        }
      });

      if (words[nounIndex + 1] === "out" && words[nounIndex + 2] === "of") {
        adjective = words[nounIndex + 2];
      }
    }

    const word = adjective ? `${adjective} ${noun}` : noun;
    const command = `SHOW>${nounMap[word]}>${number}`;

    console.log(command);

    this._queue.push(command);

  }

  showMove(words, verbIndex) {

  }

  moveHide(words, verbIndex) {

  }

  antiMoss(string) {
    console.log(string);
    const words = string.split(" ");

    for (let i = 0; i < words.length; i++) {

      const verb = words[i];

      if (verb === "generate") {
        this.generate();
      } else if (show.includes(verb)) {
        this.show(words, i);
      } else if (hide.includes(verb)) {
        this.hide(words, i);
      } else if (move.includes(verb)) {
        this.move(words, i);
      } else if (showMove.includes(verb)) {
        this.showMove(words, i);
      } else if (moveHide.includes(verb)) {
        this.moveHide(words, i);
      }
    }

  }
}

module.exports = BlockchainManager;
