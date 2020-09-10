import React from "react"
import { Link, graphql } from "gatsby"

export default ({ data }) => (
  <React.Fragment>
    <img src={data.dogs.message} alt="a cute dog" />
    <br />
    <Link to="/">Back to home</Link>
  </React.Fragment>
)

export const query = graphql`
  query {
    dogs {
      message
    }
  }
`
