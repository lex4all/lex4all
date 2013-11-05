import unittest
import os
from DummyApp import *

class TestDummyInput(unittest.TestCase):

    def setUp(self):
        make_lexicon(dict(), "sample_output.pls")

    def test_file_exists(self):
        self.assertTrue(os.path.exists("sample_output.pls"))

    def test_content_correct(self):
        with open("samplelexicon.xml", 'r') as ref_file:
            reference = ref_file.read()
        with open("sample_output.pls", 'r') as out_file:
            output = out_file.read()
        self.assertEqual(output, reference)

    def tearDown(self):
        os.remove("sample_output.pls")


class TestOtherInput(unittest.TestCase):

    def setUp(self):
        self.fixture = make_lexicon({"a":"b"}, "blahblah.xml")

    def test_not_handled_msg(self):
        self.assertEqual(self.fixture, "Sorry, I can't handle that yet!")

    def tearDown(self):
        del self.fixture

if __name__ == "__main__":
    unittest.main()
