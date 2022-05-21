# Next.js Project Starter

This repository aims to handle most of the setup required when creating a new Next.js project. The setup of ESLint, Prettier, Jest and Testing Library has already been handled.

The editor of choice is VS Code, thus only the configuration for this code editor is provided.

It is opinionated providing a recommended folder structure.

## How to use?

Once cloned you will want to install the required dependencies using your package manager of choice.

```
npm install
pnpm install
yarn install
```

In `package.json` update the `"name"` property to match the name of your application. Whilst the file is open make a mental note of the various scripts which can be run.

Don't forget to:

- Remove the old `.git` directory and reinitialise the repository.
- Update or delete `license.txt`.
- Update or delete `README.md`.

### VS Code Users

The following extensions should be installed for full functionality, and benefits of this project:

- [ESLint](https://marketplace.visualstudio.com/items?itemName=dbaeumer.vscode-eslint) - picks ups any linting errors as you code.
- [Prettier](https://marketplace.visualstudio.com/items?itemName=esbenp.prettier-vscode) - automatically formats your code on save (in this particular configuration).
- [CSS Modules](https://marketplace.visualstudio.com/items?itemName=clinyong.vscode-css-modules) - autocompletes class names from `module.css` files when importing into a React component.

## What's included?

This project has already set-up the main tools you will need to write clean consistent code.

- [`normalize.css`](https://necolas.github.io/normalize.css/) - _"makes browsers render all elements more consistently and in line with modern standards. It precisely targets only the styles that need normalizing."_
- ESLint with Airbnb style guide - start conforming to some form of style guide. This is highly configurable, rules which you do not need can be disabled. Additionally, the `.eslintignore` file contains any patterns which should be ignored by ESLint, in this case any `*.config.js` files.
- Prettier - to ensure consistency and less hassle from ESLint when writing code.
- Jest and Testing Library - allows testing to start happening outside the box.

## Folder Structure

The project contains a simple page with a `Button` component to showcase the expected structure of the project.

- `./src/pages` - **ONLY** for pages, non-page components, e.g. Buttons, should be stored in `./src/common/components`.
  - Next.js has optimisations at the page level, every component file under this directory will be treated as a page drastically increasing build time. [Stackoverflow Thread discussing this.](https://stackoverflow.com/a/59924145)
- `./src/__tests__` - any tests which cannot go next to the component file, e.g. tests for components in `pages` directory.
- `./src/styles` - any styles which cannot go next to the component `.tsx` file, e.g. styles for pages.
- `./src/common` - non-page components and types.
- `./src/common/components/[Component Name]` - a component `.tsx`, it's style `.module.css` and test files `.spec.tsx`.
  - Type specific for the component can go in the `.tsx` file
- `./src/common/types` - reusable types.
- `./public` - store static files, such as images, `robots.txt`, and `favicon.ico`, here.

## Branches

- `main` - as described above.
- `with-stitches` - uses Stitches for design instead of `styled-jsx` and CSS Modules.

## License

[MIT](license.txt)
