import React from "react"
import { Link, graphql } from "gatsby"

export default ({ data }) => (
  <React.Fragment>
    <ul>
      {data.cars.Results.map(item => (
        <li>
          {item.Make_Name} {item.Model_Name}
        </li>
      ))}
    </ul>
    <Link to="/">Back to home</Link>
  </React.Fragment>
)

export const query = graphql`
  query {
    cars {
      Results {
        Make_Name
        Make_ID
        Model_Name
        Model_ID
      }
    }
  }
`
