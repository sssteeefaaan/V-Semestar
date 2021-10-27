let counter = function ()
{
    let count = 0;

    function display()
    {
        console.log(count);
    };

    function increase()
    {
        count++;
        display();
    };

    return {
        increase
    }
};

let counter2 = counter();
counter2.increase();

let counter3 = counter();
counter3.increase();
counter3.increase();

counter2.increase();

still("Bonjour");