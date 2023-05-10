
try {
    const toggleBtn = document.querySelector('[data-option="toggle"]')
    toggleBtn.addEventListener('click', function () {
        const element = document.querySelector(toggleBtn.getAttribute('data-target'))

        if (!element.classList.contains('open-menu')) {
            element.classList.add('open-menu')
            element.classList.add('container-fluid')
            toggleBtn.classList.add('btn-outline-dark')
            toggleBtn.classList.add('btn-toggle-white')
        }

        else {
            element.classList.remove('container-fluid')
            element.classList.remove('open-menu')
            toggleBtn.classList.remove('btn-outline-dark')
            toggleBtn.classList.remove('btn-toggle-white')
        }
    })
} catch { }

// Footer position
function footerPosition(element, scrollHeight, innerHeight) {
    try {
        const _element = document.querySelector(element)
        const isTallerThanScreen = scrollHeight >= (innerHeight + _element.scrollHeight)

        _element.classList.toggle('position-fixed-bottom', !isTallerThanScreen)
        _element.classList.toggle('position-static', isTallerThanScreen)
    } catch { }
}
footerPosition('footer', document.body.scrollHeight, window.innerHeight)

// Product details navbar
const navItems = document.querySelectorAll('.product-details-nav-item');

navItems.forEach(function (navItem) {
    navItem.addEventListener('click', function () {
        const targetId = navItem.getAttribute('data-target');
        const targetText = document.getElementById(targetId);
        navItems.forEach(function (item) {
            item.classList.remove('active');
        });
        navItem.classList.add('active');
        const texts = document.querySelectorAll('.product-details-text div');
        texts.forEach(function (text) {
            text.classList.remove('active');
        });
        targetText.classList.add('active');
    });
});

// Register form validation
// Get references to the input fields and error spans
const firstNameInput = document.getElementById('firstName');
const lastNameInput = document.getElementById('lastName');
const streetNameInput = document.getElementById('streetName');
const postalCodeInput = document.getElementById('postalCode');
const cityInput = document.getElementById('city');
const emailInput = document.getElementById('email');
const passwordInput = document.getElementById('password');
const confirmPasswordInput = document.getElementById('confirmPassword');
const errorSpans = document.getElementsByClassName('error');

// Add event listeners to the input fields
firstNameInput.addEventListener('input', validateFirstName);
lastNameInput.addEventListener('input', validateLastName);
streetNameInput.addEventListener('input', validateStreetName);
postalCodeInput.addEventListener('input', validatePostalCode);
cityInput.addEventListener('input', validateCity);
emailInput.addEventListener('input', validateEmail);
passwordInput.addEventListener('input', validatePassword);
confirmPasswordInput.addEventListener('input', validateConfirmPassword);


document.addEventListener("DOMContentLoaded", function () {
    var form = document.getElementById("registerForm");
    form.addEventListener("submit", function (event) {
        validateFirstName();
        validateLastName();
        validateStreetName();
        validatePostalCode();
        validateCity();
        validateEmail();
        validatePassword();
        validateConfirmPassword();

        if (!validateCheckbox() ||
            !validateFirstName() ||
            !validateLastName() ||
            !validateStreetName() ||
            !validatePostalCode() ||
            !validateCity() ||
            !validateEmail() ||
            !validatePassword() ||
            !validateConfirmPassword() )
        {
            event.preventDefault(); // Prevent form submission
        }
    });
});

// Validation functions
function validateFirstName() {
    if (firstNameInput.value.trim() === '') {
        showError(firstNameInput, 'First name is required');
        return false;

    } else {
        hideError(firstNameInput);
        return true;

    }
}

function validateLastName() {
    if (lastNameInput.value.trim() === '') {
        showError(lastNameInput, 'Last name is required');
        return false;
    } else {
        hideError(lastNameInput);
        return true;

    }
}

function validateStreetName() {
    if (streetNameInput.value.trim() === '') {
        showError(streetNameInput, 'Street name is required');
        return false;
    } else {
        hideError(streetNameInput);
        return true;

    }
}

function validatePostalCode() {
    if (postalCodeInput.value.trim() === '') {
        showError(postalCodeInput, 'Postal code is required');
        return false;
    } else {
        hideError(postalCodeInput);
        return true;

    }
}

function validateCity() {
    if (cityInput.value.trim() === '') {
        showError(cityInput, 'City is required');
        return false;
    } else {
        hideError(cityInput);
        return true;

    }
}

function validateEmail() {
    const email = emailInput.value.trim();
    if (email === '') {
        showError(emailInput, 'Email is required');
        return false;
    } else if (!isValidEmail(email)) {
        showError(emailInput, 'Invalid email address');
        return false;
    } else {
        hideError(emailInput);
        return true;

    }
}

function validatePassword() {
    const password = passwordInput.value.trim();
    if (password === '') {
        showError(passwordInput, 'Password is required');
        return false;
    } else if (password.length < 8) {
        showError(passwordInput, 'Password must be at least 8 characters long');
        return false;
    } else {
        hideError(passwordInput);
        return true;

    }
}

function validateConfirmPassword() {
    const confirmPassword = confirmPasswordInput.value.trim();
    const password = passwordInput.value.trim();
    if (confirmPassword === '') {
        showError(confirmPasswordInput, 'Please confirm your password');
        return false;
    } else if (confirmPassword !== password) {
        showError(confirmPasswordInput, 'Passwords do not match');
        return false;
    } else {
        hideError(confirmPasswordInput);
        return true;

    }
}

function validateCheckbox() {
    var isChecked = document.getElementById("terms").checked;
    if (isChecked) {
        document.getElementById("termsError").classList.remove("field-validation-error");
        document.getElementById("termsError").classList.add("field-validation-valid");
        document.getElementById("termsError").textContent = "";
        return true;
    } else {
        document.getElementById("termsError").classList.remove("field-validation-valid");
        document.getElementById("termsError").classList.add("field-validation-error");
        document.getElementById("termsError").textContent = "You must agree to the terms and conditions";
        return false;
    }
}

// Utility functions
function showError(input, message) {
    const errorSpan = input.nextElementSibling;
    errorSpan.textContent = message;
}

function hideError(input) {
    const errorSpan = input.nextElementSibling;
    errorSpan.textContent = '';
}

function isValidEmail(email) {
    // Regular expression to validate email address
    const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    return emailRegex.test(email);
}
