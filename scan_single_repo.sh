#!/bin/bash
# ============================================================
#  scan_single_repo.sh — Dành cho các team tự quét repo
#  Usage: ./scan_single_repo.sh [path_to_repo]
# ============================================================

REPO_PATH="${1:-.}"
REPORT_FILE="secret_scan_$(date +%Y%m%d_%H%M%S).json"

RED='\033[0;31m'; GREEN='\033[0;32m'; YELLOW='\033[1;33m'; NC='\033[0m'

echo "=========================================="
echo " 🔍 Secret Scanner — $(basename $(realpath $REPO_PATH))"
echo "=========================================="

# Check gitleaks
if ! command -v gitleaks &>/dev/null; then
  echo -e "${RED}gitleaks chưa được cài. Xem hướng dẫn cài đặt trong tài liệu.${NC}"
  exit 1
fi

# Scan including full git history
echo -e "\n${YELLOW}Đang quét source code và git history...${NC}\n"

if gitleaks detect \
    --source="$REPO_PATH" \
    --report-format=json \
    --report-path="$REPORT_FILE" \
    --redact \
    -v 2>&1; then
  echo -e "\n${GREEN}✅ Không phát hiện secrets. Repo sạch!${NC}"
  rm -f "$REPORT_FILE"
else
  COUNT=$(jq 'length' "$REPORT_FILE" 2>/dev/null || echo "?")
  echo -e "\n${RED}⚠️  Phát hiện $COUNT secret(s)!${NC}"
  echo -e "Chi tiết xem trong file: ${YELLOW}$REPORT_FILE${NC}"
  echo ""
  echo "Các loại secrets thường gặp:"
  jq -r '.[].RuleID' "$REPORT_FILE" 2>/dev/null | sort | uniq -c | sort -rn | head -10
  echo ""
  echo -e "${YELLOW}Hành động cần làm:${NC}"
  echo "  1. Revoke/rotate key ngay lập tức"
  echo "  2. Xóa khỏi code và git history (xem hướng dẫn)"
  echo "  3. Báo cáo Security team nếu key đã bị lộ ra public"
fi
