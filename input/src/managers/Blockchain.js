const Wordpos = require("wordpos");

const wordpos = new Wordpos();

const show = ["built", "was", "were"];
const hide = ["eight", "down"];
const move = ["came"];
const showMove = [];
const moveHide = ["ate"];

const numbers = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "eleven", "twelve"];
const numberth = ["zero", "first", "second", "third", "fourth", "fifth", "sixth", "seventh"];
const badNouns = ["a", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve"];

const nounMap = {
  background: "blue",
  ground: "green",
  pig: "Pig/pig",
  pigs: "Pig/pig",
  house: "HOUSE",
  "straw house": "StrawHouse/medievalhouse",
  "brick house": "BrickHouse/Prefabs/Baker_house",
  fireplace: "FirePlace/Prefabs/FP2015",
  tree: "Tree/MinecraftTree",
  dog: "Wolf/kodi",
};

const adjectiveMap = {

};

class BlockchainManager {
  constructor(commandService) {
    this._commandService = commandService;
    this._queue = [];
    this._gameObjects = [];
    this.sendCommand = this.sendCommand.bind(this);
    this.antiMoss = this.antiMoss.bind(this);

    this.generate = this.generate.bind(this);
    this.show = this.show.bind(this);
    this.hide = this.hide.bind(this);
    this.move = this.move.bind(this);
    this.showMove = this.showMove.bind(this);
    this.moveHide = this.moveHide.bind(this);
    this.isAdjective = this.isAdjective.bind(this);

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
      let word = words[i];

      if (numbers.includes(word)) {
        number = numbers.indexOf(word);
      }

      let willBreak = false;

      let isNoun = await new Promise(resolve => {
        wordpos.isNoun(word, isNoun => resolve(isNoun));
      }) && !badNouns.includes(word);

      if (!isNoun && word[word.length - 1] === "s") {
        word = word.substring(0, word.length - 1);
        isNoun = await new Promise(resolve => {
          wordpos.isNoun(word, isNoun => resolve(isNoun));
        }) && !badNouns.includes(word);
      }

      if (!isNoun && word[word.length - 1] === "e") {
        word = word.substring(0, word.length - 1);
        isNoun = await new Promise(resolve => {
          wordpos.isNoun(word, isNoun => resolve(isNoun));
        }) && !badNouns.includes(word);
      }

      if (isNoun) {
        noun = word;
        nounIndex = i;
        willBreak = true;
      }

      if (willBreak) {
        break;
      }
    }

    if (nounIndex) {

      const isPrevWordAdjective = await this.isAdjective(words[nounIndex - 1]);
      if (isPrevWordAdjective) {
        adjective = words[nounIndex - 1];
      }

      if (words[nounIndex + 1] === "out" && words[nounIndex + 2] === "of") {
        adjective = words[nounIndex + 2];
      }
    }

    const word = adjective && !badNouns.includes(adjective) ? `${adjective} ${noun}` : noun;
    const prefab = nounMap[word];
    const command = `SHOW>${prefab}>${number}`;


    this._queue.push(command);

    for (let i = 0; i < number; i++) {
      this._gameObjects.push(prefab);
    }
  }


  hide(words, verbIndex) {

  }

  async move(words, verbIndex) {

    let noun1 = "";
    let nounIndex1;
    let adjective1 = "";
    let number1;
    let noun2 = "";
    let nounIndex2;
    let adjective2 = "";
    let number2;

    // find first noun
    for (let i = verbIndex - 1; i >= 0; i--) {
      const word = words[i];

      let willBreak = false;

      const isNoun = await new Promise(resolve => {
        wordpos.isNoun(word, isNoun => resolve(isNoun));
      });

      const isReallyNoun = !badNouns.includes(word) && isNoun;
      if (isReallyNoun) {
        noun1 = word;
        nounIndex1 = i;
        willBreak = true;
      }

      if (willBreak) {
        break;
      }
    }

    if (!nounIndex1) {
      return;
    }

    // find second noun
    for (let i = nounIndex1 + 1; i < words.length; i++) {
      const word = words[i];

      let willBreak = false;

      const isNoun = await new Promise(resolve => {
        wordpos.isNoun(word, isNoun => resolve(isNoun));
      });

      const isReallyNoun = !badNouns.includes(word) && isNoun;
      if (isReallyNoun) {
        noun2 = word;
        nounIndex2 = i;
        willBreak = true;
      }

      if (willBreak) {
        break;
      }
    }

    if (!nounIndex2) {
      return;
    }






    const isAdjective1 = await this.isAdjective(words[nounIndex1 - 1]);
    if (isAdjective1) {
      adjective1 = words[nounIndex1 - 1];
    }

    if (words[nounIndex1 + 1] === "out" && words[nounIndex1 + 2] === "of") {
      adjective1 = words[nounIndex1 + 2];
    }

    if (numberth.includes(words[nounIndex1 - 1])) {
      number1 = number
    }


    const word = adjective1 ? `${adjective1} ${noun1}` : noun1;
    const command = `SHOW>${nounMap[word]}>${number}`;

    console.log(command);

    this._queue.push(command);

  }

  showMove(words, verbIndex) {

  }

  moveHide(words, verbIndex) {

  }

  isAdjective(word) {
    return new Promise(resolve => {
      wordpos.isAdjective(word, isAdjective => resolve(isAdjective));
    });
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
