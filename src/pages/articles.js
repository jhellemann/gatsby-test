import React from "react"
import { Link, graphql } from "gatsby"
import { documentToReactComponents } from "@contentful/rich-text-react-renderer"
import Layout from "../components/layout"

export default ({ data }) => (
  <Layout>
    {data.allContentfulArticle.edges.map(item => (
      <div>
        <h2>
          {item.node.title} <small>({item.node.year})</small>
        </h2>
        {documentToReactComponents(item.node.body.json)}
        <hr />
      </div>
    ))}
    <Link to="/">Back to home</Link>
  </Layout>
)

export const query = graphql`
  query {
    allContentfulArticle(sort: { fields: order, order: ASC }) {
      edges {
        node {
          body {
            json
          }
          title
          order
          year
        }
      }
    }
  }
`
