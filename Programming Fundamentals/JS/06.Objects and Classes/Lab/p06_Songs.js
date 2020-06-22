function solve(tokens = []) {
  class Song {
    constructor(type, name, time) {
      this.type = type;
      this.name = name;
      this.time = time;
    }
  }

  let songs = [];
  let numberOfSongs = tokens.shift();
  let songType = tokens.pop();

  for (let i = 0; i < numberOfSongs; i++) {
    let [type, name, time] = tokens[i].split('_');
    songs.push(new Song(type, name, time));
  }

  if (songType === 'all') {
    songs.forEach(x => console.log(x.name));
  } else {
    let filtered = songs.filter(x => x.type === songType);
    filtered.forEach(x => console.log(x.name));
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve([3, 'favourite_DownTown_3:14', 'favourite_Kiss_4:16', 'favourite_Smooth Criminal_4:01', 'favourite']);
solve([4, 'favourite_DownTown_3:14', 'listenLater_Andalouse_3:24', 'favourite_In To The Night_3:58', 'favourite_Live It Up_3:48', 'listenLater']);
solve([2, 'like_Replay_3:15', 'ban_Photoshop_3:48', 'all']);
