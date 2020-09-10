import React, { useState, useEffect } from "react"
import { Link, useStaticQuery } from "gatsby"

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
    <React.Fragment>
      <h4>This is a static dog:</h4>
      <img src={data.dogs.message} alt="a cute static dog" />
      <br />
      <h4>This is a random dog:</h4>
      <img src={randomDog} alt="a cute random dog" />
      <br />
      <Link to="/">Back to home</Link>
    </React.Fragment>
  )
}

export default DogsPage
