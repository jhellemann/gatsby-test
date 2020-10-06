import React from "react"
import { Link } from "gatsby"

import Layout from "../components/layout"
import Image from "../components/image"
import SEO from "../components/seo"

const IndexPage = () => (
  <Layout>
    <SEO title="Home" />
    <h1>Hi people</h1>
    <p>Welcome to your new Gatsby site created by H3llm4n.</p>
    <p>Now go build something great.</p>
    <div style={{ maxWidth: `300px`, marginBottom: `1.45rem` }}>
      <Image />
    </div>
    <Link to="/using-typescript/">Using TypeScript</Link> <br />
    <Link to="/articles/">Read some articles</Link> <br />
    <Link to="/dogs/">Get your daily random dog</Link> <br />
    <Link to="/image/">Image of an astronaut on the moon</Link> <br />
    <Link to="/star-wars/">Star Wars charachters</Link> <br />
    <Link to="/weather/">Weather</Link> <br />
  </Layout>
)

export default IndexPage
