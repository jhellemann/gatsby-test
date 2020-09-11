import React, { useState, useEffect } from "react"
import { Link, useStaticQuery } from "gatsby"
import Layout from "../components/layout"

const DogsPage = () => {
  const data = useStaticQuery(graphql`
    query {
      dogs {
        message
      }
    }
  `)

  // Client-side Runtime Data Fetching
  const [randomDog, setRandomDog] = useState(0)
  useEffect(() => {
    fetch(`https://dog.ceo/api/breeds/image/random`)
      .then(response => response.json())
      .then(resultData => {
        setRandomDog(resultData.message)
      })
  }, [])

  return (
    <Layout>
      <h2>
        Get your daily random dog from{" "}
        <a href="https://dog.ceo/dog-api/">Dog API</a>
      </h2>
      <h4>
        This is a "build time" dog that will only be changed upon a new build:
      </h4>
      <img src={data.dogs.message} alt="a cute static dog" />
      <br />
      <h4>
        This is a random "runtime" dog that will change on every page refresh:
      </h4>
      <img src={randomDog} alt="a cute random dog" />
      <br />
      <Link to="/">Back to home</Link>
    </Layout>
  )
}

export default DogsPage
