"""python engine compatibility module.

Examples:
    ```python
    from pyrevit.compat import IRONPY341, PY3
    ```
"""

import sys
from System import Environment

NET_FRAMEWORK_VERSION = Environment.Version.Major == 4
NET_CORE_VERSION = Environment.Version.Major >= 8

PY3 = sys.version_info[0] == 3
PY2 = sys.version_info[0] == 2
IRONPY341 = sys.version_info[:3] == (3, 4, 1)


__builtins__["unicode"] = str

import configparser as configparser
import urllib
import winreg as winreg
from collections.abc import Iterable
from urllib.parse import urlparse

safe_strtype = str


def urlopen(url):
    """Urlopen wrapper.

    Args:
        url (str): request url
    """
    return urllib.request.urlopen(url)


def make_request(url, headers, data):
    """Urlopen wrapper to create and send a request.

    Args:
        url (str): request url
        headers (dict[str, str]): headers
        data (bytes | None): request data
    """
    req = urllib.request.Request(url, headers, data)
    urllib.request.urlopen(req).close()
