import Face from "./Face";

import classes from "./Cube.module.css";

const Cube = (props) => {
    return <div className={classes.cube}>
        <Face face="up" state={props.state.substring(0, 9)}/>
        <Face face="left" state={props.state.substring(9, 18)}/>
        <Face face="front" state={props.state.substring(18, 27)}/>
        <Face face="right" state={props.state.substring(27, 36)}/>
        <Face face="back" state={props.state.substring(36, 45)}/>
        <Face face="down" state={props.state.substring(45, 54)}/>
    </div>;
};

export default Cube;