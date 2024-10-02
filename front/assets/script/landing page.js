// courses slider
const dots = document.querySelectorAll(".dot")
const cards = document.querySelectorAll(".card")
let selected_dot = 0

dots.forEach((dot , i)=>{
    dot.addEventListener("click" , ()=>{
        // mark the selected dot
        dots[selected_dot].classList.remove("selected")
        dot.classList.add("selected")
        selected_dot = i

        // slide between cards
        cards.forEach(card=>{
            card.style.transform = `translateX(-${330 * selected_dot}%)` 
        })
    })
})


// feedback slider
const next = document.querySelector(".next")
const prev = document.querySelector(".prev")
const feedback_cards = document.querySelectorAll(".feedback-card")
let index = 0

next.addEventListener("click" , ()=>{
    index++
    checkDisability()

    // slide cards
    feedback_cards.forEach(card=>{
        card.style.transform = `translateX(calc(-${100 * index}% - ${20 * index}px))`
    })
})
prev.addEventListener("click" , ()=>{
    index--
    checkDisability()

    // slide cards
    feedback_cards.forEach(card=>{
        card.style.transform = `translateX(calc(-${100 * index}% - ${20 * index}px))`
    })
})

// check the disability state of the buttons
function checkDisability() {
    prev.disabled = (index === 0)
    next.disabled = (index === feedback_cards.length-5)
}