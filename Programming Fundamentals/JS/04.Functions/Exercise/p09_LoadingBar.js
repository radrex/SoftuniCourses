function visualizeLoadingBar(loadedPercentage) {
  if (loadedPercentage === 100) {
    console.log('100% Completed');
    printLoadingBar(loadedPercentage);
  } else {
    printLoadingBar(loadedPercentage);
    console.log('Still loading...');
  }

  function printLoadingBar(loadedPercentage) {
    let loadingBar = '';
    loadingBar += (loadedPercentage !== 100) ? `${loadedPercentage}% [` : '[';

    loadedPercentage /= 10;
    for (let i = 0; i < loadedPercentage; i++) {
      loadingBar += '%';
    }

    loadedPercentage = 10 - loadedPercentage;
    for (let i = 0; i < loadedPercentage; i++) {
      loadingBar += '.';
    }
    loadingBar += ']';

    console.log(loadingBar);
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
visualizeLoadingBar(30);
visualizeLoadingBar(50);
visualizeLoadingBar(100);
