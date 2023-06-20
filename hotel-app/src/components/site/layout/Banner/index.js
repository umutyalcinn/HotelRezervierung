import "./style.css"

const Banner = (props) => {
    
    return(
        <div class="banner">
            <img src={props.banner} width={props.width} height={props.height} />
        </div>
    )
}

export default Banner;
