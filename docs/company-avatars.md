Just a bunch of random notes about how to organize and play this game:

1. Stop just thinking of stock ticker, the game, and go for something that models the real world.
1. Create company avatars for stocks.
1. Players choose a quantity of stock at a certain value and keep that.
1. The game should be either turn based, or it could also be client/server/multiplayer or have both modes.
1. Stocks should move up and down on a set clock
    1. The stock movement should be determined by the following:
        <pre> Level 1 Avatars {Stocks, Bonds, Commodities}
        Level 2 Avatars { Technology, Finance, Food & Beverage, Manufacturing}, {Government, Corporate}, {Metals, Energy, Livestock & Meat, Agricultural}}
        
         Level 3 Avatars -> this will include the individual avatars for each Level 2 avatar.
       </pre>
    1. At each level there is a random Up/Down "role of the dice"
    1. Each level 3 avatar has a risk quotient represented by a decimal _q_ where 1 &geq; _r_ &lt; 2
    1. At each level a multiplier is calculated using this algorithm
        > Given a random decimal _r_ where 0 &gt; _r_ &lt; 1
        >
        > multiplier = risk quotient * 
# Entity Avatars

## Stocks
### Technology
### Finance
### Food & Beverage
### Manufacturing

## Bonds
### Government
- Treasury 
- Federal
- Municipal
### Corporate 
- Mortgage


## Commodity
### Metals 
- Gold
- Silver
- Copper
- Platinum
### Energy
- Oil
### Livestock & Meat
- Cattle
- Pork
### Agricultural
- Oranges
- Sugar
- Soybeans

## Entity Chart
<table>
<tr><th>Level 1</th><th>Level 2</th><th>Level 3</th><th>Risk Quotient</th></tr>
<tr><td>Stock</td><td>Technology</td><td></td><td></td></tr>
<tr><td>Stock</td><td>Finance</td><td></td><td></td></tr>
<tr><td>Stock</td><td>Food & Beverage</td><td></td><td></td></tr>
<tr><td>Stock</td><td>Manufacturing</td><td></td><td></td></tr>
<tr><td>Bonds</td><td>Corporate</td><td>Mortgage</td><td></td></tr>
<tr><td>Commodity</td><td>Metals</td><td>Gold</td><td></td></tr>
<tr><td>Commodity</td><td>Metals</td><td>Silver</td><td></td></tr>
<tr><td>Commodity</td><td>Metals</td><td>Copper</td><td></td></tr>
<tr><td>Commodity</td><td>Metals</td><td>Platinum</td><td></td></tr>
<tr><td>Commodity</td><td>Energy</td><td>Oil</td><td></td></tr>
<tr><td>Commodity</td><td>Livestock & Meat</td><td>Cattle</td><td></td></tr>
<tr><td>Commodity</td><td>Livestock & Meat</td><td>Pork</td><td></td></tr>
<tr><td>Commodity</td><td>Agricultural</td><td>Oranges</td><td></td></tr>
<tr><td>Commodity</td><td>Agricultural</td><td>Sugar</td><td></td></tr>
<tr><td>Commodity</td><td>Agricultural</td><td>Soybeans</td><td></td></tr>
</table>
