USER STORY #1
As an inventory management user, I can load a flight schedule similar to the one listed in the Scenario above. For
this story you do not yet need to load the orders. I can also list out the loaded flight schedule on the console.
<br>

Expected output:
Flight: 1, departure: YUL, arrival: YYZ, day: 1
<br>
...
<br>
Flight: 6, departure: <departure_city>, arrival: <arrival_city>, day: x
<br>

USER STORY #2
As an inventory management user, I can generate flight itineraries by scheduling a batch of orders. These flights
can be used to determine shipping capacity.
<br>

Expected output:
order: order-001, flightNumber: 1, departure: <departure_city>, arrival: <arrival_city>, day: x 
<br>
...
<br>
order: order-099, flightNumber: 1, departure: <departure_city>, arrival: <arrival_city>, day: x
<br>
if an order has not yet been scheduled, output:
<br>
order: order-X, flightNumber: not scheduled
