module TravellingSalesmanProblem.Lookup

open TravellingSalesmanProblem.Types

let buildLookup cities =
    cities
    |> Array.collect (fun c ->
        let calcDistance from to' =
            ((from.X - to'.X) ** 2.0) + ((from.Y - to'.Y) ** 2.0) |> sqrt
        
        let distanceToOtherCities =
            cities
            |> Array.filter (fun s' -> s' <> c)
            |> Array.map (fun s' ->
                let distance = calcDistance c.Location s'.Location
                ((c, s'), distance))
        distanceToOtherCities)
    |> dict
