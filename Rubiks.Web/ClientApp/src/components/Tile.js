import classes from './Tile.module.css';

const Tile = (props) => {
    return <div className={`${classes.tile} ${classes[props.colour]}`}>
    </div>;
};

export default Tile;