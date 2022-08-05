# Desafío 4: **Consumir datos de endpoints**

Al ser ejecutado el proyecto se debe poder consumir datos de los siguientes endpoints:

● Api Currencies de Mercado Libre: Link a la API
● Api Currency Conversion de Mercado Libre: Link a la API

El objetivo es que se logre almacenar en disco un json con la estructura que devuelve el endpoint Api Currencies de Mercado Libre. Adicionalmente se debe incluir una nueva property “todolar” con el resultado del endpoint Api Currency Conversion de Mercado Libre Tené en cuenta que: El endpoint Currency Conversion toma como parámetro en “from” el id de moneda correspondiente a un país. Id que es devuelto por el endpoint Currencies - Para más información podés consultar la documentación de Mercado Libre sobre Ubicación y Monedas.

Adicionalmente la misma aplicación tiene que almacenar en disco un archivo csv con cada uno de los resultados obtenidos de “currency_conversions”, es decir debe almacenar sólo los resultados obtenidos de la property “ratio” (Ej: 0.0147275, 0.013651,0.727565).