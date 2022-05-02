import Tile from "./Tile";

import classes from './Face.module.css'

const colours = {
    "W": "white",
    "O": "orange",
    "G": "green",
    "R": "red",
    "B": "blue",
    "Y": "yellow"
};

const Face = (props) => {
    const tiles = [];

    for (let row = 0; row < 3; row++) {
        for (let col = 0; col < 3; col++) {
            const colour = colours[props.state.charAt(row * 3 + col)];
            tiles.push(<Tile colour={colour} key={`${row}${col}`}/>);
        }
    }

    return <div className={`${classes.face} ${classes[props.face]}`}>
        {tiles}
    </div>;
};

export default Face;