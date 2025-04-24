const container = document.getElementById("container");

var data = await fetch("https://pokeapi.co/api/v2/pokemon?limit=151")
            .then(response => response.json());

var array = data.results


async function fetchData() {
    for (const pokemon of array) {
        var data = await fetch(pokemon.url)
            .then(response => response.json());

        container.innerHTML += `
            <div style="width: 120px; height: 140px; 
                        font-weight: bold;
                        border: solid 2px rgb(214, 214, 214);
                        border-radius: 6px;
                        background-color: white; margin: 10px;">
                <p style="width: fit-content; margin: 5px auto;">${pokemon.name}</p>
                <img style="margin: auto;" src="${data.sprites.back_default}" alt="">
            </div>
        `;
    }
}

fetchData()

