//const imgs = document.getElementById('imgs')
//const leftBtn = document.getElementById('left')
//const rightBtn = document.getElementById('right')

//const img = document.querySelectorAll('#imgs img')

//let idx = 0

//let interval = setInterval(run, 2000)

//function run() {
//    idx++
//    changeImage()
//}

//function changeImage() {
//    if (idx > img.length - 1) {
//        idx = 0
//    } else if (idx < 0) {
//        idx = img.length - 1
//    }

//    imgs.style.transform = `translateX(${-idx * 500}px)`
//}

//function resetInterval() {
//    clearInterval(interval)
//    interval = setInterval(run, 2000)
//}

//rightBtn.addEventListener('click', () => {
//    idx++
//    changeImage()
//    resetInterval()
//})

//leftBtn.addEventListener('click', () => {
//    idx--
//    changeImage()
//    resetInterval()
//})
function showTime() {
    var date = new Date();
    var h = date.getHours(); // 0 - 23
    var m = date.getMinutes(); // 0 - 59
    var s = date.getSeconds(); // 0 - 59
    var session = "AM";

    if (h == 0) {
        h = 12;
    }

    if (h > 12) {
        h = h - 12;
        session = "PM";
    }

    h = (h < 10) ? "0" + h : h;
    m = (m < 10) ? "0" + m : m;
    s = (s < 10) ? "0" + s : s;

    var time = h + ":" + m + ":" + s + " " + session;
    document.getElementById("MyClockDisplay").innerText = time;
    document.getElementById("MyClockDisplay").textContent = time;

    setTimeout(showTime, 1000);

}

showTime();