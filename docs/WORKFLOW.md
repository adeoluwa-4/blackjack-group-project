
# WORKFLOW — Git & GitHub

## One-time
1. Install Git.
2. Create a new GitHub repo (Public or Private). Do **NOT** add a starter template.
3. On your laptop:
   ```bash
   git clone <your-repo-url>
   cd <repo>
   # copy the contents of this ZIP into the cloned folder, then:
   git add .
   git commit -m "chore: add documentation-first starter"
   git push origin main
   ```

## Daily
- **Branch per task**:
  ```bash
  git checkout -b feat/deck
  # make changes
  git add -A
  git commit -m "feat(core): implement Deck with Fisher–Yates"
  git push -u origin feat/deck
  ```
- Open a **Pull Request** on GitHub. Ask a teammate to review.
- Merge after review and CI passes (if set up).

## If you prefer the web UI
- You can upload the **ZIP** to create the repo quickly:
  - Create repo ➜ **Add file > Upload files** ➜ drag `blackjack-spec-starter.zip` and **Commit**.
  - Then on your laptop: `git clone` that repo and continue with branches/PRs.
