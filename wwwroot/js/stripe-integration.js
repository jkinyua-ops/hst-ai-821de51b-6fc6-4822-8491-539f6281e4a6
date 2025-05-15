let stripe;
let elements;

async function initializeStripe(clientSecret) {
    stripe = Stripe('YOUR_STRIPE_PUBLISHABLE_KEY');
    elements = stripe.elements();

    const style = {
        base: {
            color: "#32325d",
            fontFamily: 'Arial, sans-serif',
            fontSmoothing: "antialiased",
            fontSize: "16px",
            "::placeholder": {
                color: "#32325d"
            }
        },
        invalid: {
            fontFamily: 'Arial, sans-serif',
            color: "#fa755a",
            iconColor: "#fa755a"
        }
    };

    const card = elements.create("card", { style: style });
    card.mount("#card-element");

    card.on('change', ({error}) => {
        const displayError = document.getElementById('card-errors');
        if (error) {
            displayError.textContent = error.message;
        } else {
            displayError.textContent = '';
        }
    });
}

async function confirmPayment() {
    const result = await stripe.confirmCardPayment(clientSecret, {
        payment_method: {
            card: elements.getElement('card'),
        }
    });

    if (result.error) {
        console.log(result.error.message);
        return false;
    } else {
        if (result.paymentIntent.status === 'succeeded') {
            return true;
        }
    }
    return false;
}

window.initializeStripe = initializeStripe;
window.confirmPayment = confirmPayment;