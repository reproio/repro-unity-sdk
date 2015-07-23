#! /bin/bash

NEW_VERSION=$(cat ./package/Repro/Plugins/VERSION)
COMMENT="bump: $NEW_VERSION"
BRANCH=$(git rev-parse --abbrev-ref HEAD)

git add .

git commit -m "$COMMENT"
git push origin "$BRANCH"

git tag -a "$NEW_VERSION" -m "$COMMENT"
git push --tag
