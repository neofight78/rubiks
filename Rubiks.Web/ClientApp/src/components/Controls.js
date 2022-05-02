import classes from "./Controls.module.css";

const Face = {
    Front: "Front",
    Up: "Up",
    Right: "Right",
    Down: "Down",
    Left: "Left",
    Back: "Back"
}

const Direction = {
    Clockwise: "Clockwise",
    AntiClockwise: "AntiClockwise"
};

const Controls = (props) => {
    return <div className={classes.controls}>
        <button onClick={() => props.rotate(Face.Front, Direction.Clockwise)}>F</button>
        <button onClick={() => props.rotate(Face.Right, Direction.Clockwise)}>R</button>
        <button onClick={() => props.rotate(Face.Up, Direction.Clockwise)}>U</button>
        <button onClick={() => props.rotate(Face.Back, Direction.Clockwise)}>B</button>
        <button onClick={() => props.rotate(Face.Left, Direction.Clockwise)}>L</button>
        <button onClick={() => props.rotate(Face.Down, Direction.Clockwise)}>D</button>

        <button onClick={props.reset} className={classes.reset}>Reset</button>

        <button onClick={() => props.rotate(Face.Front, Direction.AntiClockwise)}>F'</button>
        <button onClick={() => props.rotate(Face.Right, Direction.AntiClockwise)}>R'</button>
        <button onClick={() => props.rotate(Face.Up, Direction.AntiClockwise)}>U'</button>
        <button onClick={() => props.rotate(Face.Back, Direction.AntiClockwise)}>B'</button>
        <button onClick={() => props.rotate(Face.Left, Direction.AntiClockwise)}>L'</button>
        <button onClick={() => props.rotate(Face.Down, Direction.AntiClockwise)}>D'</button>
    </div>;
};

export default Controls;