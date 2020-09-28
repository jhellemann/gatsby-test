import React, { useState, useEffect } from "react"
import { Link } from "gatsby"
import Layout from "../components/layout"

const StarWarsPage = () => {
  // Client-side Runtime Data Fetching
  const [starWarsMovies, setStarWarsMovies] = useState([])
  useEffect(() => {
    fetch(`${process.env.API}/star-wars`)
      .then(response => response.json())
      .then(resultData => {
        setStarWarsMovies(resultData)
      })
  }, [])

  return (
    <Layout>
      <h2>Star Wars movies</h2>
      <ol>
        {starWarsMovies.map(title => (
          <li>{title}</li>
        ))}
      </ol>
      <Link to="/">Back to home</Link>
    </Layout>
  )
}

export default StarWarsPage
