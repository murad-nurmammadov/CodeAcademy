let users = [
    {username: "admin", email: "admin@gmail.com", password: "admin123"},
 ];

const response = await fetch("https://jsonplaceholder.typicode.com/users");
const data = await response.json();

data.forEach(element => {
    var user = {
        username: element.username,
        email: element.email,
        password: element.website,
    };
    users.push(user);
})


console.log(users);

const signupForm = document.getElementById("signup-form");
const loginForm = document.getElementById("login-form");

signupForm.addEventListener("submit", function(event) {
    event.preventDefault();

    let username = document.getElementById("signup-username").value;
    let email = document.getElementById("signup-email").value;
    let password = document.getElementById("signup-password").value;
    let confirmPassword = document.getElementById("signup-confirm-password").value;
    const errorParagraph = document.getElementById("signup-error-message");
    errorParagraph.textContent = "";

    if (valueExists("username", username)) {
        errorParagraph.textContent = "This username already exists!!"
    }
    else if (valueExists("email", email)) {
        errorParagraph.textContent = "This email already exists!!"
    }
    else if (password != confirmPassword) {
        errorParagraph.textContent = "Passwords do not match!"
    }
    else {
        var user = {
            username: username,
            email: email,
            password: password
        };
        console.log(user);
        users.push(user);
    }
});

loginForm.addEventListener("submit", function(event) {
    event.preventDefault();

    let account = document.getElementById("login-account").value;
    let password = document.getElementById("login-password").value;
    const errorParagraph = document.getElementById("login-error-message");
    errorParagraph.textContent = "";

    if (!(valueExists("username", account) || valueExists("email", account)) 
        || !valueExists("password", password)) {
        errorParagraph.textContent = "Invalid username/email or password!!"
    }
});

function valueExists(key, value) {
    let exists = false;

    users.forEach(user => {
        if (user[key] == value) {
            exists = true;
            return exists;
        }
    });

    return exists;
}
