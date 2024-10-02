// toggle script
const btn_signup = document.querySelector("#btn-signup") 
const btn_signin = document.querySelector("#btn-signin") 
const form_container = document.querySelector(".login-form") 

btn_signup.addEventListener("click" , ()=>{
    form_container.classList.add("active")
})
btn_signin.addEventListener("click" , ()=>{
    form_container.classList.remove("active")
})

// handling fields values

// email forms 
const email_containers = document.querySelectorAll(".email-container")
const emails = document.querySelectorAll(".email")
const warning = document.createElement("p")
    warning.classList.add("warning")
    warning.textContent = "*please enter a valid email"

emails.forEach((email , i)=>{
    email.addEventListener("input" , ()=>{
        checkEmailValidity(email , email_containers[i])
    })

})

function checkEmailValidity(email_field , email_field_container){
    const emailPattern =  /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/; 
    if (emailPattern.test(email_field.value.toLowerCase()) || email_field.value == ""){
        email_field_container.removeChild(warning)
    }else{
        email_field_container.appendChild(warning)
    }
}

// password signup form
const password = document.getElementById("password")

const password_strength = document.querySelector(".password-strength")
const checkboxes = document.querySelectorAll(".password-strength label input")

password.addEventListener("input",()=>{
    passwordStrengthCheck(password)
})

function passwordStrengthCheck(password_field){
    const special_characters = /[@#&!$%^*()\-_=+\\[\]{};:,.?]/

    let value = password_field.value
    let contain_upperCase = /[A-Z]/.test(value)
    let contain_special = special_characters.test(value)
    let contain_space =  /\s/.test(value)

    if((contain_upperCase && contain_special && password.value.length > 8 && contain_space == false)|| value.length===0){
        password_strength.classList.remove("active")
    }else{
        password_strength.classList.add("active")
    }

    checkboxes[0].checked = contain_upperCase
    checkboxes[1].checked = contain_special
    checkboxes[2].checked = value.length >= 8
    checkboxes[3].checked = !contain_space
}