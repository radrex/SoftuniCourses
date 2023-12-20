var domElement = document.getElementById('root');
var rootReactElement = ReactDOM.createRoot(domElement);

// Simple JS syntax to create and reuse React components
// const h1Element = React.createElement('h1', null, 'Hello from React!');
// const h2Element = React.createElement('h2', null, 'Some slogan here');
// const headerElement = React.createElement('header', null, h1Element, h2Element);

// Adding JSX to a Project. JSX is a lot like adding a CSS preprocessor, the only requirement is to have Node.js installed
// 1 - Initialize app with the following command: npm init --yes
// 2 - Then run: npm install babel-cli@6 babel-preset-react-app@3
// 3 - JSX syntax - Command for running the JSX Preprocessor: npx babel --watch ./src --out-dir ./build --presets react-app/prod , after ruuning it it will generate the React code in build folder
// 4 - Optional - Additional command "start" extracted in package.json it can be runned from terminal using "npm run start-babel-transpiler" directly

var headerElement =
// JSX code below (superset of JS) -> babel transpiler will convert it to React code and save it in build folder
React.createElement(
    "header",
    { className: "header-container" },
    React.createElement(
        "h1",
        { className: "heading1" },
        "Hello from React!"
    ),
    React.createElement(
        "h2",
        null,
        "Some slogan here"
    ),
    React.createElement(
        "p",
        null,
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean gravida lacus sit amet dui pellentesque elementum."
    )
);

rootReactElement.render(headerElement);