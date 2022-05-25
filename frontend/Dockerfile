# syntax=docker/dockerfile:1

FROM node:17.9.0-alpine AS deps
WORKDIR /app
COPY package.json yarn.lock ./
RUN yarn install --frozen-lockfile

FROM node:17.9.0-alpine as base
WORKDIR /app
COPY --from=deps /app/node_modules ./node_modules


# Dev
FROM base as dev
WORKDIR /app
COPY package.json .
EXPOSE 3000
CMD ["yarn", "dev"]


# Prod Builder
FROM base as builder
WORKDIR /app
COPY . .
RUN yarn build

# Prod
FROM node:17.9.0-alpine AS runner
WORKDIR /app

ENV NODE_ENV production

RUN addgroup --system --gid 1001 nodejs
RUN adduser --system --uid 1001 nextjs

COPY --from=builder /app/public ./public
COPY --from=builder /app/package.json ./package.json

COPY --from=builder --chown=nextjs:nodejs /app/.next/standalone ./
COPY --from=builder --chown=nextjs:nodejs /app/.next/static ./.next/static

USER nextjs

EXPOSE 3000

ENV PORT 3000

CMD ["node", "server.js"]