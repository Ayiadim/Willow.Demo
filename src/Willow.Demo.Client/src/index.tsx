import * as React from "react";
import * as ReactDOM from "react-dom";

const render = () => {
    const App = require("./components/App").default;

    ReactDOM.render(
        <App/>,
        document.getElementById("root")
    );
};

render();