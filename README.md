# BlazorAppWeatherDemo

Testar att då sidan laddas köra JS från .NET som efterfrågar position.
Callback som anropas från JS om position fås är en .NET funktion som i sin tur gör ett API-anrop och returnerar data till anropande JS-funktion som nyttjar datat och uppdaterar webbsidan.

1. [Loading...]
2. (call JS, set callback, JS get geolocation coordinates, call .NET, call API, return data to JS, update HTML)
3. [It's xx°C at your location now.]

See __\_Layout.cshtml__ and __WeatherAtYou.razor__ for details.
