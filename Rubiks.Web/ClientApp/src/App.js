import {useState} from "react";
import Controls from "./components/Controls";
import Cube from "./components/Cube";

import './App.module.css';

const initialState = "WWWWWWWWWOOOOOOOOOGGGGGGGGGRRRRRRRRRBBBBBBBBBYYYYYYYYY";

const App = () => {
    const [state, setState] = useState(initialState);

    const rotateClickHandler = async (face, direction) => {
        const response = await fetch('rubiks/rotate?' + new URLSearchParams({
            state: state,
            face: face,
            direction: direction
        }));
        setState(await response.text());
    };

    const resetClickHandler = () => {
        setState(initialState);
    };

    return <div>
        <Cube state={state}/>
        <Controls rotate={rotateClickHandler} reset={resetClickHandler}/>
    </div>;
};

export default App;