function solve(browserHistory = {}, additionalCommands = []) {
  const [browser, logs, opened, closed] = ['Browser Name', 'Browser Logs', 'Open Tabs', 'Recently Closed'];

  additionalCommands.forEach(command => browserHistory[logs].push(command));
  let regex = new RegExp('(Open|Close|Clear History and Cache)\\s?(.*)');
  
  for (let i = 0; i < browserHistory[logs].length; i++) {
    let [, command, site] = regex.exec(browserHistory[logs][i]);
    switch (command) {
      case 'Open':
        browserHistory[opened].push(site);
        break;

      case 'Close':
        if (browserHistory[opened].includes(site)) {
          browserHistory[opened] = browserHistory[opened].filter(x => x !== site);
          browserHistory[closed].push(site);
        } else {
          browserHistory[logs].splice(i, 1);
        }

        break;

      case 'Clear History and Cache':
        browserHistory[opened].length = 0;
        browserHistory[closed].length = 0;
        let index = browserHistory[logs].indexOf(command);
        browserHistory[logs].splice(0, index + 1);
        break;
      
      default:
        break;
    }
  }

  removeDuplicatedBackwards(opened);
  removeDuplicatedBackwards(closed);

  function removeDuplicatedBackwards(flag) {
    for (let i = browserHistory[flag].length - 1; i >= 1; i--) {
      for (let j = i - 1; j >= 0; j--) {
        if (browserHistory[flag][i] === browserHistory[flag][j]) {
          browserHistory[flag].splice(j, 1);
        }
      }
    }
  }

  console.log(browserHistory[browser]);
  console.log(`Open Tabs: ${browserHistory[opened].join(', ')}`);
  console.log(`Recently Closed: ${browserHistory[closed].join(', ')}`);
  console.log(`Browser Logs: ${browserHistory[logs].join(', ')}`);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve({"Browser Name":"Google Chrome",
       "Open Tabs":["Facebook","YouTube","Google Translate"],
       "Recently Closed":["Yahoo","Gmail"],
       "Browser Logs":["Open YouTube","Open Yahoo","Open Google Translate","Close Yahoo","Open Gmail","Close Gmail","Open Facebook"]
      },
      ["Close Facebook", "Open StackOverFlow", "Open Google"]
);

solve({"Browser Name":"Mozilla Firefox",
       "Open Tabs":["YouTube"],
       "Recently Closed":["Gmail", "Dropbox"],
       "Browser Logs":["Open Gmail", "Close Gmail", "Open Dropbox", "Open YouTube", "Close Dropbox"]
      },
      ["Open Wikipedia", "Clear History and Cache", "Open Twitter"]
);
