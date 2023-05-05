
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


// Product details page

const toggleProductDetails = (event) => {
    let thisId = event.target.id
    let productDetailsTexts = document.querySelectorAll(`[id^="product-id-"][id$="text"]`)
    productDetailsTexts.forEach(removeActive)
    function removeActive(item) {
        item.classList.remove("active")
    }
    document.getElementById(`${thisId}-text`).classList.add('active')
}
