import React from "react"
import { Link, graphql } from "gatsby"
import { documentToReactComponents } from "@contentful/rich-text-react-renderer"
import Layout from "../components/layout"

export default ({ data }) => (
  <Layout>
    {data.allContentfulArticle.edges.map(item => (
      <div>
        <h2>{item.node.title}</h2>
        {documentToReactComponents(item.node.longText.json)}
        <hr />
      </div>
    ))}
    <Link to="/">Back to home</Link>
  </Layout>
)

export const query = graphql`
  query {
    allContentfulArticle {
      edges {
        node {
          title
          longText {
            json
          }
        }
      }
    }
  }
`
