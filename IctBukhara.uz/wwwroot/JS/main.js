
function drop_toggle(a) {

    switch (a) {
        case 0:
            document.querySelector("#modal_r").style.display = "flex";
            break;
        case 1:
            document.querySelector("#modal_r").style.display = "none";
            break;
        case 3:
            document.querySelector("#modal_h").style.display = "none";
            break;
        case 4:
            document.querySelector("#modal_t").style.display = "none";
            document.querySelector("#modal_t_x").style.display = "none";
            break;
        case 5:
            document.querySelector("#modal_t").style.display = "flex";
            document.querySelector("#modal_r").style.display = "none";
            break;
        case 6:
            document.querySelector("#modal_t_x").style.display = "flex";
            document.querySelector("#modal_r").style.display = "none";
            break;
        default:
            break;
    }
}

function menu(a) {

    switch (a) {
        case 0:
            document.querySelector(".och").style.display = "none"
            document.querySelector(".yop").style.display = "block"
            document.querySelector(".ul_menu").style.display = "none"
            break;
        case 1:
            document.querySelector(".yop").style.display = "none"
            document.querySelector(".och").style.display = "block"
            document.querySelector(".ul_menu").style.display = "flex"
            break;
        default:
            break;
    }
}


function formatPhoneNumber(str) {
    document.getElementById('phone').value = str.replace(/\D/g, '');
}

var widthWindow = window.innerWidth;
navbarLoad();
window.onresize = () => {
    widthWindow = window.innerWidth;
    navbarLoad();
}

function navbarLoad() {
    if (widthWindow > 670) {
        document.querySelector(".ul_menu").style.display = "flex";
    } else {
        document.querySelector(".ul_menu").style.display = "none";
    }
}